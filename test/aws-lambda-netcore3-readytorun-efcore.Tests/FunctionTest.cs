using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using aws_lambda_netcore3_readytorun;
using Microsoft.EntityFrameworkCore;

namespace aws_lambda_netcore3_readytorun.Tests
{
    public class FunctionTest
    {

        [Fact]
        public void TestServiceGetListMember()
        {
            var _options = new DbContextOptionsBuilder<MemberContext>().UseInMemoryDatabase("member_service").Options;
            var _context = new DistrictContext(_options);

            _context.Members.Add(
                new Member { 
                        Id = 1,
                        Firstname = "Chitpong",
                        Lastname = "Wuttanan"
                    });
            _context.Members.Add(
                new Member { 
                        Id = 2,
                        Firstname = "Jim",
                        Lastname = "Carrey"
                    });
            _context.SaveChanges();

            List<Member> expected = new List<Member> { 
                    new Member { 
                        Id = 1,
                        Firstname = "Chitpong",
                        Lastname = "Wuttanan"
                    },
                    new Member { 
                        Id = 2,
                        Firstname = "Jim",
                        Lastname = "Carrey"
                    }
                };

            Services _service = new Services(_context);
            List<Member> result = _service.List_member();

            Assert.Equal(expected.Count, result.Count);
            Assert.Equal(expected[0].Id, result[0].Id);
            Assert.Equal(expected[1].Id, result[1].Id);
            Assert.Equal(expected[0].Firstname, result[0].Firstname);
            Assert.Equal(expected[1].Firstname, result[1].Firstname);
            Assert.Equal(expected[0].Lastname, result[0].Lastname);
            Assert.Equal(expected[1].Lastname, result[1].Lastname);
        }
    }
}
