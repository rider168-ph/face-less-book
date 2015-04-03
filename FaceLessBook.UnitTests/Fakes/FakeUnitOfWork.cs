using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FaceLessBook.Domain.Contracts.Data;
using FaceLessBook.Domain.Models;
using FaceLessBook.TestData;

namespace FaceLessBook.UnitTests.Fakes
{
	public class FakeUnitOfWork : IUnitOfWork
	{
        public bool Committed { get; set; }

	    public FakeUnitOfWork()
	    {
	        Committed = false;

	        Users = new FakeRepository<User>();
            Friends = new FakeFriendRepository();
	    }

        #region IUnitOfWork implementations

        public void Commit()
	    {
            Committed = true;
	    }

	    public IFriendRepository Friends { get; private set; }
	    public IRepository<User> Users { get; private set; }

        #endregion
    }
}
