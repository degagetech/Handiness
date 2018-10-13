using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq.Expressions;
namespace Handiness2.Schema.Exporter.Windows
{
    public class SchemaDifferenceInfo
    {
        public IObjectSchema Schema { get; set; }
        public SchemaDifferenceType DifferenceType { get; set; }
    }
    public class SchemaEqualizer
    {
        public SchemaEqualizer(Func<IObjectSchema, IObjectSchema, Boolean> func)
        {
            _internalSchemaEqualizer = func;
        }
        private Func<IObjectSchema, IObjectSchema, Boolean> _internalSchemaEqualizer;
        public Boolean Equal(IObjectSchema source, IObjectSchema target)
        {
            return _internalSchemaEqualizer.Invoke(source, target);
        }

        public static implicit operator SchemaEqualizer(Func<IObjectSchema, IObjectSchema, Boolean> func)
        {
            return new SchemaEqualizer(func);
        }


        public static implicit operator SchemaEqualizer(Expression<Func<IObjectSchema, IObjectSchema, Boolean>> expression)
        {
            return new SchemaEqualizer(expression.Compile());
        }


    }
}
