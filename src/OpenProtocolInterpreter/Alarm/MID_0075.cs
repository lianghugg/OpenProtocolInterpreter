﻿namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm acknowledged on controller acknowledge
    /// Description: 
    ///      Acknowledgement of MID 0074 Alarm acknowledged on controller.
    /// Message sent by: Integrator
    /// Answer : None
    /// </summary>
    public class MID_0075 : Mid, IAlarm
    {
        private const int LAST_REVISION = 2;
        public const int MID = 75;

        public MID_0075(int revision = LAST_REVISION) : base(MID, revision)
        {

        }

        internal MID_0075(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
