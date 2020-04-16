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
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Text.RegularExpressions;

namespace NOpenMessaging.Internals
{
    /**
     * Represents a <a href="https://github.com/openmessaging/specification/blob/master/oms_access_point_schema.md">AccessPoint String</a>.
     * The Connection String describes the details to connect a specific OMS service provider.
     */
    internal class AccessPointURI
    {
        private static readonly string PREFIX = "oms:";

        private readonly string accessPointString;
        private readonly string driverType;
        private readonly string accountId;
        private readonly string hosts;
        private readonly string region;

        /**
         * The standard OMS access point schema is:
         * <p>
         * {@literal oms:<driver_type>://[account_id@]host1[:port1][,host2[:port2],...[,hostN[:portN]]]/<region>}
         * <p>
         *
         * More details please refer to:
         * <a href="https://github.com/openmessaging/specification/blob/master/oms_access_point_schema.md">Access Point Schema</a>
         */
        private static readonly string PATTERN = "^oms:.+://.+/.+$";

        public AccessPointURI(string accessPointString)
        {
            validateAccessPointString(accessPointString);
            this.accessPointString = accessPointString;
            string unprocessedString = accessPointString.Substring(PREFIX.Length);

            // Split out the user OMS driver info
            int idx = unprocessedString.IndexOf(":");
            this.driverType = unprocessedString.Substring(0, idx);

            //Skip '<driver_type>://'
            unprocessedString = unprocessedString.Substring(driverType.Length + 3);

            idx = unprocessedString.LastIndexOf('/');

            this.region = unprocessedString.Substring(idx + 1);
            string userAndHostInformation = unprocessedString.Substring(0, idx);

            idx = userAndHostInformation.IndexOf('@');

            if (idx > 0)
            {
                accountId = userAndHostInformation.Substring(0, idx);
                hosts = userAndHostInformation.Substring(idx + 1);
            }
            else
            {
                hosts = userAndHostInformation;
                accountId = null;
            }
        }

        public string getAccessPointString()
        {
            return accessPointString;
        }

        public string getDriverType()
        {
            return driverType;
        }

        public string getAccountId()
        {
            return accountId;
        }

        public string getHosts()
        {
            return hosts;
        }

        public string getRegion()
        {
            return region;
        }

        private void validateAccessPointString(string accessPointString)
        {
            if (!Regex.IsMatch(accessPointString, PATTERN))
            {
                throw OMSResponseStatus.generateException(OMSResponseStatus.STATUS_10001, accessPointString);
            }
        }
    }
}