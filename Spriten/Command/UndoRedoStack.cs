using System.Collections.Generic;

namespace Spriten.Command
{
    public class UndoRedoStack<T>
    {
        private Stack<ICommand<T>> mUndo;
        private Stack<ICommand<T>> mRedo;

        public int UndoCount
        {
            get
            {
                return mUndo.Count;
            }
        }

        public int RedoCount
        {
            get
            {
                return mRedo.Count;
            }
        }

        public UndoRedoStack()
        {
            Reset();
        }

        public void Reset()
        {
            mUndo = new Stack<ICommand<T>>();
            mRedo = new Stack<ICommand<T>>();
        }

        public T Do(ICommand<T> command, T input)
        {
            T output = command.Do(input);
            mUndo.Push(command);
            mRedo.Clear();
            return output;
        }

        public T Undo(T input)
        {
            if(mUndo.Count > 0)
            {
                ICommand<T> command = mUndo.Pop();
                T output = command.Undo(input);
                mRedo.Push(command);
                return output;
            }
            else
            {
                return input;
            }
        }

        public T Redo(T input)
        {
            if(mRedo.Count > 0)
            {
                ICommand<T> command = mRedo.Pop();
                T output = command.Do(input);
                mUndo.Push(command);
                return output;
            }
            else
            {
                return input;
            }
        }
    }
}
