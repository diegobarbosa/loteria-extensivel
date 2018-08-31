using System;
using System.Collections.Generic;
using System.Text;

namespace Itix.Loteria.Core.Domain.Servicos
{
    public interface ISequenceGenerator
    {
        int NextIdFor(Type type);
    }

    public class SequenceGenerator: ISequenceGenerator
    {
        Dictionary<Type, int> ids = new Dictionary<Type, int>();

        public int NextIdFor(Type type)
        {
            if (!ids.ContainsKey(type))
            {
                ids[type] = 0;
            }

            ids[type]++;

            return ids[type];

        }
    }
}
