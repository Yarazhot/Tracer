using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace tracer_lib
{
    public class Tracer
    {
        public List<Thread_Info> threads;
        private Dictionary<Thread_Info, Stack<Method_Info>> t_stacks = new Dictionary<Thread_Info, Stack<Method_Info>>();
        //private Dictionary<MethodBase, Method_Info> m_infos = new Dictionary<MethodBase, Method_Info>;
        private object locker = new object();
        void StartTrace()
        {
            int cur_t_id;
            Thread_Info cur_t_inf;
            lock (locker)
            {
                //найти поток с таким айди или создать новый
                if ((cur_t_inf = FindThrById(cur_t_id = Thread.CurrentThread.ManagedThreadId)) == null)
                {
                    Thread_Info new_t_inf = new Thread_Info(cur_t_id);
                    threads.Add(new_t_inf);
                    t_stacks.Add(new_t_inf, new Stack<Method_Info>());
                    new_t_inf.time = "0";
                }

                Stack<Method_Info> cur_t_stack;
                t_stacks.TryGetValue(cur_t_inf, out cur_t_stack);
                MethodBase cur_m_base = GetCurrentMethod();
                Method_Info cur_m_inf = new Method_Info();
                //m_infos.Add(cur_m_base, cur_m_inf);
                cur_t_stack.Push(cur_m_inf);

                cur_m_inf.name = cur_m_base.Name;
                cur_m_inf.class_name = cur_m_base.ReflectedType.Name;
                cur_m_inf.methods = new List<Method_Info>();
                cur_m_inf.stopwatch = new Stopwatch();
                cur_m_inf.stopwatch.Start();
            }
            
        }
        void StopTrace()
        {
            Thread_Info cur_t_inf;
            lock (locker)
            {
                //найти поток с таким айди
                cur_t_inf = FindThrById(Thread.CurrentThread.ManagedThreadId);

                Stack<Method_Info> cur_t_stack;
                t_stacks.TryGetValue(cur_t_inf, out cur_t_stack);
                Method_Info cur_m_inf = cur_t_stack.Pop();

                cur_m_inf.stopwatch.Stop();
                cur_m_inf.time = Convert.ToString(cur_m_inf.stopwatch.ElapsedMilliseconds);
                cur_t_inf.time = Convert.ToString(Convert.ToInt32(cur_t_inf.time) + cur_m_inf.stopwatch.ElapsedMilliseconds);
                Method_Info parent_m_inf;
                if ((parent_m_inf = cur_t_stack.Peek()) != null)
                    parent_m_inf.methods.Add(cur_m_inf);
                else
                    cur_t_inf.methods.Add(cur_m_inf);
            }
        }
        public List<Thread_Info> GetTraceResult()
        {
            return threads;
        }
        private Thread_Info FindThrById(int id)
        {
            foreach (Thread_Info thread in threads)
                if (thread.id == id.ToString())
                    return thread;
            return null;
        }
        private MethodBase GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);
            return sf.GetMethod();
        }
    }
}
