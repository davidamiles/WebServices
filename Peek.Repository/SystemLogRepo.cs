using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Repository
{
    public class SystemLogRepo : ISystemLogRepo
    {
        private Entities.PeekViewSystemEntities baseContext = null;

        public SystemLogRepo()
        {
            this.baseContext = new Entities.PeekViewSystemEntities();
        }

        public void Insert(Models.SystemLogModel item)
        {
            this.baseContext.SystemLogs.Add(new Entities.SystemLog()
            {
                Timestamp = item.Timestamp,
                Message = item.Message,
                Component = item.Component,
                Severity = item.Severity.ToString(),
                Stacktrace = item.StackTrace
            });

            this.baseContext.SaveChanges();
        }

        public void Update(Models.SystemLogModel item)
        {
            throw new NotImplementedException();
        }

        public Models.SystemLogModel Select(Models.SystemLogModel item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.SystemLogModel> Select()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.SystemLogModel> Select(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public void Delete(Models.SystemLogModel item)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Models.SystemLogModel item)
        {
            throw new NotImplementedException();
        }
    }
}
