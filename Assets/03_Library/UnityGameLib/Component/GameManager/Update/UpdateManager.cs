using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPattern;


namespace GameManager
{
        /// <summary>
        /// �t���[������̉e�����󂯂邩
        /// </summary>
        public enum FrameControl
        {
            ON,
            OFF,
        }

        public interface IUpdateManager
        {
            /// <summary>
            /// �t���[�����Ƃ�OnUpdate�֐����Ă΂��
            /// </summary>
            /// <param name="deltaTime"></param>
            void OnUpdate(double deltaTime);
        }

        /// <summary>
        /// Update�֐����Ǘ�����class
        /// </summary>
        public class UpdateManager : Singleton<UpdateManager>
        {
            [Header("FrameControl��ON")]
            [SerializeField,Header("�I�u�W�F�N�g��")]
            
            private short objOnCount;

            [Header("FrameControl��OFF")]
            [SerializeField, Header("�I�u�W�F�N�g��")]
            
            private short objOFFCount;

            private List<IUpdateManager> objON,objOFF;

            private  bool frameState;

            public override void Init()
            {
                frameState = false;
                objON = new List<IUpdateManager>(objOnCount);
                objOFF = new List<IUpdateManager>(objOFFCount);
            }

            public void Bind(IUpdateManager u,FrameControl f)
            {
            
                switch (f)
                {
                    case FrameControl.ON:

                        objON.Add(u);

                        break;

                    case FrameControl.OFF:

                        objOFF.Add(u);

                        break;
                }
            }

            public void UnBind(IUpdateManager u, FrameControl f)
            {
                switch (f)
                {
                    case FrameControl.ON:

                        objON.Remove(u);

                        break;

                    case FrameControl.OFF:

                        objOFF.Remove(u);

                        break;
                }
            }

            /// <summary>
            /// OnUpdate�֐��̃t���[���������J�n
            /// </summary>
            public void FrameStart()
            {
                bool start = false;
                
                frameState = start;
                
            }

            /// <summary>
            /// OnUpdate�֐��̃t���[���������~
            /// </summary>
            public void FrameStop()
            {
                bool stop = true;

                frameState = stop;
            }

            private void FrameControls(List<IUpdateManager> list,double d)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].OnUpdate(d);
                }
            }

            private void Frame()
            {
                double deltaTime = Time.deltaTime;

                FrameControls(objOFF,deltaTime);

                if (frameState) return;

                FrameControls(objON, deltaTime);
            }

            void Update()
            {                
                Frame();
            }                       
        }   
}
