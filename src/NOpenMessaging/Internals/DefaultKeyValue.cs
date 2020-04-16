/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace NOpenMessaging.Internals
{


    /**
     * The default implementation of the interface {@link KeyValue}, used by OMS internally.
     *
     * @version OMS 1.0.0
     * @since OMS 1.0.0
     */
    internal class DefaultKeyValue : IKeyValue
    {
        private ConcurrentDictionary<string, string> properties;
        public DefaultKeyValue()
        {
            properties = new ConcurrentDictionary<string, string>();
        }

        public IKeyValue put(string key, bool value)
        {
            properties.AddOrUpdate(key, value.ToString(), (k, o) => value.ToString());
            return this;
        }

        public bool getBoolean(string key)
        {
            if (!properties.ContainsKey(key))
            {
                return false;
            }
            return bool.Parse(properties[key]);
        }

        public bool getBoolean(string key, bool defaultValue)
        {
            return properties.ContainsKey(key) ? getBoolean(key) : defaultValue;
        }

        public short getShort(string key)
        {
            if (!properties.ContainsKey(key))
            {
                return 0;
            }
            return short.Parse(properties[key]);
        }

        public short getShort(string key, short defaultValue)
        {
            return properties.ContainsKey(key) ? getShort(key) : defaultValue;
        }

        public IKeyValue put(string key, short value)
        {
            properties.AddOrUpdate(key, value.ToString(), (k, o) => value.ToString());
            return this;
        }

        public IKeyValue put(string key, int value)
        {
            properties.AddOrUpdate(key, value.ToString(), (k, o) => value.ToString());
            return this;
        }

        public IKeyValue put(string key, long value)
        {
            properties.AddOrUpdate(key, value.ToString(), (k, o) => value.ToString());
            return this;
        }

        public IKeyValue put(string key, double value)
        {
            properties.AddOrUpdate(key, value.ToString(), (k, o) => value.ToString());
            return this;
        }

        public IKeyValue put(string key, string value)
        {
            properties.AddOrUpdate(key, value.ToString(), (k, o) => value.ToString());
            return this;
        }

        public int getInt(string key)
        {
            if (!properties.ContainsKey(key))
            {
                return 0;
            }
            return int.Parse(properties[key]);
        }

        public int getInt(string key, int defaultValue)
        {
            return properties.ContainsKey(key) ? getInt(key) : defaultValue;
        }

        public long getLong(string key)
        {
            if (!properties.ContainsKey(key))
            {
                return 0;
            }
            return long.Parse(properties[key]);
        }

        public long getLong(string key, long defaultValue)
        {
            return properties.ContainsKey(key) ? getLong(key) : defaultValue;
        }

        public double getDouble(string key)
        {
            if (!properties.ContainsKey(key))
            {
                return 0;
            }
            return double.Parse(properties[key]);
        }

        public double getDouble(string key, double defaultValue)
        {
            return properties.ContainsKey(key) ? getDouble(key) : defaultValue;
        }

        public string getString(string key)
        {
            return properties[key];
        }

        public string getString(string key, string defaultValue)
        {
            return properties.ContainsKey(key) ? getString(key) : defaultValue;
        }

        public ISet<string> keySet()
        {
            return new HashSet<string>(properties.Keys);
        }

        public bool containsKey(string key)
        {
            return properties.ContainsKey(key);
        }
    }
}