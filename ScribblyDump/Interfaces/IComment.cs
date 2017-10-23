using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScribblyDump.Models;

namespace ScribblyDump.Interfaces
{
    interface IComment
    {
        void AddComment(Comment obj);

        void AlterComment(Comment obj);

        void DeleteComment(Comment obj);

        void MarkAsBad(Comment obj);


    }
}
