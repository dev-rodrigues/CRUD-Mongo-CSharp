using AgendaMongo.DAO;
using AgendaMongo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMongo.Config
{
    class ServiceLab
    {
        private static Dictionary<Type, Type> dependencies = new Dictionary<Type, Type> {
            [ typeof( IAgendaDAO ) ] = typeof( AgendaDAO )
        };

        internal static T GetInstanceOf<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}