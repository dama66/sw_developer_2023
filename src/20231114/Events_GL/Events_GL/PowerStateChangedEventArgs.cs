using System;

namespace Events_GL
{
    internal class PowerStateChangedEventArgs : EventArgs
    {

        private DevicePower _oldState;
        private DevicePower _newState;

        public PowerStateChangedEventArgs(DevicePower oldState, DevicePower newState)
        {
            _oldState = oldState;
            _newState = newState;
        }

        public DevicePower NewState { get { return _newState; } }

        public DevicePower OldState { get { return _oldState;} }


    }
}