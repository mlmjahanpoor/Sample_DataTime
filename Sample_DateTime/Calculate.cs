namespace Sample_DateTime
{
    public class Calculate
    {
        public double GetDiffBetweenTwoDateTime(DateTime date1, DateTime date2)
        {
            return (date2 - date1).TotalDays + 1;
        }

        public List<DateTime> GetTotalLeavesWithoutHolidays(List<DateTime> holidays)
        {
            var requests = new List<Request>
            {
                new Request
                {
                    FromDate = DateTime.Now.AddDays(-5),
                    ToDate = DateTime.Now.AddDays(-3)
                },

                new Request
                {
                    FromDate = DateTime.Now.AddDays(-2),
                    ToDate = DateTime.Now
                }
            };

            var x = requests.Where(r => (r.ToDate.Date - r.FromDate.Date).TotalDays > 0).ToList();

            var result = new List<DateTime>();

            foreach (var request in x)
            {
                var y = Enumerable.Range(0, (int)(request.ToDate.Date - request.FromDate.Date).TotalDays + 1)
                    .Select(d => request.FromDate.AddDays(d).Date).ToList();

                var res = y.Except(holidays.Select(d=>d.Date).ToList());

                result.AddRange(res);
            }

            return result;
        }

        public class Request
        {
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
        }
    }
}
