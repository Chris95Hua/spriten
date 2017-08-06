using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spriten.Command
{
    public interface ICommand<T>
    {
        T Do(T input);
        T Undo(T input);
    }
    
}
