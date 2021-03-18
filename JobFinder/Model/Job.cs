using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Model
{
    public class Job
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Created_at { get; set; }
        public string Company { get; set; }
        public string Company_url { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string How_to_apply { get; set; }
        public string Company_logo { get; set; }
    }
}
