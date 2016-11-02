/***************************************************************************
 * Copyright 2013 Opher Shachar
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 **************************************************************************/

using System.Collections;
using System.Threading;

namespace Gh.Os.Concurrent
{
    public class BlockingQueue : Queue
    {
        public static Queue Create()
        {
            BlockingQueue _q1 = new BlockingQueue();
            Queue _q2 = Queue.Synchronized(_q1);
            _q1._SR = _q2.SyncRoot;

            return _q2;
        }

        private object _SR = null;
      
        private BlockingQueue() { }

        public override void Enqueue(object obj)
        {
            base.Enqueue(obj);
            Monitor.Pulse(this._SR);
        }

        public override object Dequeue()
        {
            while (this.Count == 0)
            {
                Monitor.Wait(this._SR);
            }
            return base.Dequeue();
        }
    }
}
