﻿// Copyright 2013-2014 Albert L. Hives
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace HareShow
{
    using System;
    using HareDu;
    using HareDu.Resources;
    using Quartz;

    public class HareShowStatsJob :
        IJob
    {
        public HareShowStatsJob()
        {
            Console.WriteLine("This works!!!");
        }

        public void Execute(IJobExecutionContext context)
        {
            string username = context.JobDetail.JobDataMap.GetString("username");
            string password = context.JobDetail.JobDataMap.GetString("password");
            var stats = HareDuGlobal.Client
                                    .Factory<OverviewResources>(x => x.Credentials(username, password))
                                    .Get()
                                    .Data();

            // TODO: write stats to presistent storage here (MongoDB for starters)
        }
    }
}