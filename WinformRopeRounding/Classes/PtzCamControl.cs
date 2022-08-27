using OnvifMedia10;
using OnvifPTZService;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Net;

namespace WinformRopeRounding.Classes
{
    public class PtzCamControl
    {
        public enum ActButtons { None, Up, UpRight, Right, DownRight, Down, DownLeft, Left, UpLeft, Zoom, ZoomOut, ZoomIn, Home };

        MediaClient mediaClient;
        PTZClient ptzClient;
        Profile profile;
        OnvifPTZService.PTZSpeed velocity;
        PTZConfigurationOptions options;
        bool initialised = false;

        public string ErrorMessage { get; private set; }

        public bool Initialised { get { return initialised; } }


        public async Task<bool> InitialiseAsync(string cameraAddress, string userName, string password)
        {
            bool result = false;

            try
            {
                var messageElement = new TextMessageEncodingBindingElement()
                {
                    MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None)
                };
                HttpTransportBindingElement httpBinding = new HttpTransportBindingElement()
                {
                    AuthenticationScheme = AuthenticationSchemes.Digest
                };
                CustomBinding bind = new CustomBinding(messageElement, httpBinding);
                mediaClient = new MediaClient(bind, new EndpointAddress($"http://{cameraAddress}/onvif/Media"));
                //mediaClient.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                mediaClient.ClientCredentials.HttpDigest.ClientCredential.UserName = userName;
                mediaClient.ClientCredentials.HttpDigest.ClientCredential.Password = password;
                ptzClient = new PTZClient(bind, new EndpointAddress($"http://{cameraAddress}/onvif/PTZ"));
                //ptzClient.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                ptzClient.ClientCredentials.HttpDigest.ClientCredential.UserName = userName;
                ptzClient.ClientCredentials.HttpDigest.ClientCredential.Password = password;

                var profResponse = await mediaClient.GetProfilesAsync();
                profile = await mediaClient.GetProfileAsync(profResponse.Profiles[0].token);

                var configResponse =await ptzClient.GetConfigurationsAsync();

                options = await ptzClient.GetConfigurationOptionsAsync(configResponse.PTZConfiguration[0].token);

                velocity = new OnvifPTZService.PTZSpeed()
                {
                    PanTilt = new OnvifPTZService.Vector2D()
                    {
                        x = 0,
                        y = 0,
                        space = options.Spaces.ContinuousPanTiltVelocitySpace[0].URI,
                    },
                    Zoom = new OnvifPTZService.Vector1D()
                    {
                        x = 0,
                        space = options.Spaces.ContinuousZoomVelocitySpace[0].URI,
                    }
                };
                ErrorMessage = "";
                result = initialised = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return result;
        }

        public void ActionCommand(int dir)
        {
            if (!initialised) return;

            var enumDir = (ActButtons)dir;
            Console.WriteLine(enumDir);
            switch (enumDir)
            {
                case ActButtons.None:
                    break;
                case ActButtons.Up:
                    velocity.PanTilt.x = 0;
                    velocity.PanTilt.y = 0.3f; // options.Spaces.ContinuousPanTiltVelocitySpace[0].YRange.Max;
                    ContinuousMove();
                    break;
                case ActButtons.UpRight:
                    velocity.PanTilt.x = 0.3f;
                    velocity.PanTilt.y = 0.3f;
                    ContinuousMove();
                    break;
                case ActButtons.Right:
                    velocity.PanTilt.x = 0.3f; // options.Spaces.ContinuousPanTiltVelocitySpace[0].XRange.Max;
                    velocity.PanTilt.y = 0;
                    ContinuousMove();
                    break;
                case ActButtons.DownRight:
                    velocity.PanTilt.x = 0.3f;
                    velocity.PanTilt.y = -0.3f;
                    ContinuousMove();
                    break;
                case ActButtons.Down:
                    velocity.PanTilt.x = 0;
                    velocity.PanTilt.y = -0.3f; // options.Spaces.ContinuousPanTiltVelocitySpace[0].YRange.Min;
                    ContinuousMove();
                    break;
                case ActButtons.DownLeft:
                    velocity.PanTilt.x = -0.3f;
                    velocity.PanTilt.y = -0.3f;
                    ContinuousMove();
                    break;
                case ActButtons.Left:
                    velocity.PanTilt.x = -0.3f; //options.Spaces.ContinuousPanTiltVelocitySpace[0].XRange.Min;
                    velocity.PanTilt.y = 0;
                    ContinuousMove();
                    break;
                case ActButtons.UpLeft:
                    velocity.PanTilt.x = -0.3f;
                    velocity.PanTilt.y = 0.3f;
                    ContinuousMove();
                    break;
                case ActButtons.Zoom:
                    ZoomIn();
                    break;
                case ActButtons.ZoomIn:
                    ZoomIn();
                    break;
                case ActButtons.ZoomOut:
                    ZoomOut();
                    break;
                case ActButtons.Home:
                    HomePosition();
                    break;
                default:
                    break;
            }


        }

        private void ContinuousMove()
        {
            try
            {
                ptzClient.ContinuousMoveAsync(profile.token, velocity, "PT1S");
            }
            catch
            {
            }
        }

        public void PanLeft()
        {
            if (initialised)
            {
                velocity.PanTilt.x = -0.5f; //options.Spaces.ContinuousPanTiltVelocitySpace[0].XRange.Min;
                velocity.PanTilt.y = 0;
                try
                {
                    ptzClient.ContinuousMoveAsync(profile.token, velocity, "PT1S");
                }
                catch
                {
                }
            }
        }

        public void PanRight()
        {
            if (initialised)
            {
                velocity.PanTilt.x = 0.5f; // options.Spaces.ContinuousPanTiltVelocitySpace[0].XRange.Max;
                velocity.PanTilt.y = 0;
                try
                {
                    ptzClient.ContinuousMoveAsync(profile.token, velocity, "PT1S");
                }
                catch
                {
                }
            }
        }

        public void TiltUp()
        {
            if (initialised)
            {
                velocity.PanTilt.x = 0;
                velocity.PanTilt.y = 0.3f; // options.Spaces.ContinuousPanTiltVelocitySpace[0].YRange.Max;
                try
                {
                    ptzClient.ContinuousMoveAsync(profile.token, velocity, "PT1S");
                }
                catch
                {
                }
            }
        }

        public void TiltDown()
        {
            if (initialised)
            {
                velocity.PanTilt.x = 0;
                velocity.PanTilt.y = -0.3f; // options.Spaces.ContinuousPanTiltVelocitySpace[0].YRange.Min;
                try
                {
                    ptzClient.ContinuousMoveAsync(profile.token, velocity, "PT1S");
                }
                catch
                {
                }
            }
        }

        public async void HomePosition()
        {
            try
            {
                await ptzClient.GotoHomePositionAsync(profile.token, velocity);
            }
            catch
            {
            }
        }

        public void SetPosition(string text)
        {

            if (ptzClient == null || profile.token == null) return;
            var x = Convert.ToSingle(text.Split()[0]);
            var y = Convert.ToSingle(text.Split()[1]);
            var zoom = Convert.ToSingle(text.Split()[2]);
            try
            {
                ptzClient.AbsoluteMoveAsync(profile.token, new PTZVector
                {
                    PanTilt = new OnvifPTZService.Vector2D
                    {
                        x = x,
                        y = y
                    },
                    Zoom = new OnvifPTZService.Vector1D
                    {
                        x = zoom
                    }
                }, new OnvifPTZService.PTZSpeed
                {
                    PanTilt = new OnvifPTZService.Vector2D
                    {
                        x = 1.0f, //0.1f,
                        y = 1.0f, //0.1f
                    },
                    Zoom = new OnvifPTZService.Vector1D
                    {
                        x = 0.5f //0.1f
                    }
                });
            }
            catch
            {
            }
        }

        public async Task<string> GetPosition()
        {
            var ptz_status =await ptzClient.GetStatusAsync(profile.token); //"Profile_1"); //
            return $"{ptz_status.Position.PanTilt.x} {ptz_status.Position.PanTilt.y} {ptz_status.Position.Zoom.x}";
        }

        private void Move(float x = 0.0f, float y = 0.0f, float zoom = 0.0f)
        {
            if (ptzClient == null || profile.token == null) return;

            try
            {
                ptzClient.RelativeMoveAsync(profile.token, new PTZVector
                {
                    PanTilt = new OnvifPTZService.Vector2D
                    {
                        x = x,
                        y = y
                    },
                    Zoom = new OnvifPTZService.Vector1D
                    {
                        x = zoom
                    }
                }, new OnvifPTZService.PTZSpeed
                {
                    PanTilt = new OnvifPTZService.Vector2D
                    {
                        x = 0.1f,
                        y = 0.1f
                    },
                    Zoom = new OnvifPTZService.Vector1D
                    {
                        x = 0.1f
                    }
                });
            }
            catch
            {
            }
        }

        public void ZoomIn()
        {
            if (initialised)
            {
                Move(0.0f, 0.0f, 0.1f);
            }
        }

        public void ZoomOut()
        {
            if (initialised)
            {
                Move(0.0f, 0.0f, -0.1f);
            }
        }

        public async void Stop()
        {
            if (initialised)
            {
                try
                {
                    await ptzClient.StopAsync(profile.token, true, true);
                }
                catch
                {
                }

            }
        }

    }


}
