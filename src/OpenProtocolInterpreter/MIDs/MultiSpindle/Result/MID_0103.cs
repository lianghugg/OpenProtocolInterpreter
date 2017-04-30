﻿namespace OpenProtocolInterpreter.MIDs.MultiSpindle.Result
{
    /// <summary>
    /// MID: Multi spindle result unsubscribe
    /// Description:
    ///    Reset the subscription for the multi spindle result.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, 
    ///         Multi spindle result subscription does not exist
    /// </summary>
    public class MID_0103 : MID, IMultiSpindle
    {
        public const int MID = 103;
        private const int length = 20;
        private const int revision = 1;

        public MID_0103() : base(length, MID, revision) { }

        internal MID_0103(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0103)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
