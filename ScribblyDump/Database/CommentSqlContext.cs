using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScribblyDump.Interfaces;
using ScribblyDump.Models;

namespace ScribblyDump.Database
{
    public class CommentSqlContext : DatabaseConnection, IComment
    {
        public void AddComment(Comment obj)
        {
            throw new NotImplementedException();
        }

        public void AlterComment(Comment obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(Comment obj)
        {
            throw new NotImplementedException();
        }

        public void MarkAsBad(Comment obj)
        {
            throw new NotImplementedException();
        }
    }
}