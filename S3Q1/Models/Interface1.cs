using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Q1.Models
{
    internal interface Interface1
    {
        studentmodel Create(studentmodel model);
        studentmodel Read(long id);
        IEnumerable ReadAll();
        studentmodel Edit(studentmodel model);

        studentmodel Delete(studentmodel id);

    }
}
