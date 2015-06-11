using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using Binding = System.ServiceModel.Channels.Binding;
using PTZCameraTester.LensControl;
using PTZCameraTester.PositioningControl;
using PTZCameraTester.PelcoConfiguration;
using PTZCameraTester.PresetControl;
using PTZCameraTester.CameraConfiguration;


namespace PTZCameraTester
{
    public partial class ServiceLib
    {
        private Dictionary<Type, object> _clientList;
        protected string _cameraAddress;

        public ServiceLib(string CameraIP)
        {
            _clientList = new Dictionary<Type, object>();
            _cameraAddress = CameraIP;
        }

        protected enum ClientBindingsType
        {
            PelcoBindings
        }

        private Binding CreateBinding(ClientBindingsType bindingsType)
        {
            switch (bindingsType)
            {
                case ClientBindingsType.PelcoBindings:
                    return PelcoBinding.CreateCustomBinding();
                default:
                    throw new ApplicationException(string.Format("Unknown ClientBindingsType {0}", bindingsType));
            }
        }


        // TODO: This should all be done non-dynamically in the Camera Initialization
        // call of each child, but no time at present to change all the controls.
        protected T GetClient<T>(string address)
        {
            return GetClient<T>(address, ClientBindingsType.PelcoBindings);
        }

        protected T GetClient<T>(string address, ClientBindingsType type)
        {
            return GetClient<T>(address, CreateBinding(type));

        }

        protected T GetClient<T>(string address, Binding binding)
        {

            if (!Uri.IsWellFormedUriString(address, UriKind.Absolute))
            {
                return default(T);
            }

            if (!_clientList.ContainsKey(typeof(T)))
            {
                // create a new instance of the T client
                _clientList[typeof(T)] = (T)Activator.CreateInstance(typeof(T), binding, new EndpointAddress(address));
            }

            return (T)_clientList[typeof(T)];

        }


        protected void RemoveClient<T>()
        {
            _clientList.Remove(typeof(T));
        }

        protected void RemoveClient(Type t)
        {
            _clientList.Remove(t);
        }

        // A little funny because different pages will share a client
        protected void SetClient(Type type, object client)
        {
            _clientList[type] = client;
        }

        protected bool ClientExists(Type client)
        {
            return _clientList.ContainsKey(client);
        }
        public LensControlPortTypeClient LensClient
        {
            get
            {
                return GetClient<LensControlPortTypeClient>(LensControlAddress);
            }
        }

        public PositioningControlPortTypeClient PositionClient
        {
            get
            {
                return GetClient<PositioningControlPortTypeClient>(PositioningControlAddress);
            }
        }


        public PelcoConfigurationPortTypeClient PelcoClient
        {
            get
            {
                return GetClient<PelcoConfigurationPortTypeClient>(PelcoConfigurationAddress);
            }
        }

        public PresetControlPortTypeClient PresetClient
        {
            get
            {
                return GetClient<PresetControlPortTypeClient>(PresetControlAddress);
            }
        }

        public CameraConfigurationPortTypeClient CameraConfClient
        {
            get
            {
                return GetClient<CameraConfigurationPortTypeClient>(CameraConfigurationAddress);
            }
        }

        protected string PresetControlAddress
        {
            get
            {
                return _cameraAddress + "/control/PresetControl-2";
            }
        }

        protected string PositioningControlAddress
        {
            get
            {
                return _cameraAddress + "/control/PositioningControl-1";
            }
        }

        protected string LensControlAddress
        {
            get
            {
                return _cameraAddress + "/control/LensControl-1";
            }
        }
        protected string PelcoConfigurationAddress
        {
            get
            {
                return _cameraAddress + "/control/PelcoConfiguration-1";
            }
        }

        protected string CameraConfigurationAddress
        {
            get
            {
                return _cameraAddress + "/control/CameraConfiguration-1";
            }
        }

        protected string JPEGQuickViewAddress
        {
            get
            {
                return _cameraAddress + "/jpeg?id=2";
            }
        }

        protected int PanSpeed
        {
            set
            {
                Velocity vel = PositionClient.GetVelocity();
                vel.rotation.x = value;
                PositionClient.SetVelocity(vel);
            }
            get
            {
                return PositionClient.GetVelocity().rotation.x;
            }
        }

        protected int TiltSpeed
        {
            set
            {
                Velocity vel = PositionClient.GetVelocity();
                vel.rotation.y = value;
                PositionClient.SetVelocity(vel);
            }
            get
            {
                return PositionClient.GetVelocity().rotation.y;
            }
        }
    }
}
