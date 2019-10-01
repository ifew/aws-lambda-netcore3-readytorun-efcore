using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace aws_lambda_netcore3_readytorun
{
    public class Services
    {
        private readonly MemberContext _context;

        public Services(MemberContext context)
        {
            _context = context;
        }

        public List<Member> List_member()
        {
            return _context.Members.ToList();
        }
    }

}
