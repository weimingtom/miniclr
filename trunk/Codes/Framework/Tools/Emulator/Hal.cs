////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Reflection;
using System.Collections;
using Microsoft.SPOT.Emulator.Battery;
using Microsoft.SPOT.Emulator.Com;
using Microsoft.SPOT.Emulator.Gpio;
using Microsoft.SPOT.Emulator.Serial;
using Microsoft.SPOT.Emulator.Spi;
using Microsoft.SPOT.Emulator.Time;
using Microsoft.SPOT.Emulator.Lcd;
using Microsoft.SPOT.Emulator.Events;
using Microsoft.SPOT.Emulator.Usb;
using Microsoft.SPOT.Emulator.Memory;
using Microsoft.SPOT.Emulator.Sockets;
using Microsoft.SPOT.Emulator.Sockets.Security;
using Microsoft.SPOT.Emulator.I2c;
using Microsoft.SPOT.Emulator.FS;
using Microsoft.SPOT.Emulator.BlockStorage;
using Microsoft.SPOT.Emulator.TouchPanel;
using Microsoft.SPOT.Emulator.Watchdog;

namespace Microsoft.SPOT.Emulator
{
    public class Hal : EmulatorComponent, IHal
    {
        private IBatteryDriver _battery;
        private IComDriver _com;
        private ISerialDriver _serial;
        private ISpiDriver _spi;
        private ITimeDriver _time;
        private ILcdDriver _lcd;
        private IGpioDriver _gpio;
        private IEventsDriver _events;
        private IUsbDriver _usb;
        private IMemoryDriver _memory;
        private ISocketsDriver _sockets;
        private ISslDriver _ssl;
        private II2cDriver _i2c;
        private IFSDriver _fileSystem;
        private IBlockStorageDriver _blockStorageDevices;
        private ITouchPanelDriver _touchPanel;
        private IWatchdogDriver _watchdog;

        public ITimeDriver Time
        {
            get { return _time; }
            set
            {
                ThrowIfNotConfigurable();
                _time = value;
            }
        }

        public IComDriver Com
        {
            get { return _com; }
            set
            {
                ThrowIfNotConfigurable();
                _com = value;
            }
        }

        public ILcdDriver Lcd
        {
            get { return _lcd; }
            set
            {
                ThrowIfNotConfigurable();
                _lcd = value;
            }
        }

        public ISerialDriver Serial
        {
            get { return _serial; }
            set
            {
                ThrowIfNotConfigurable();
                _serial = value;
            }
        }

        public IBatteryDriver Battery
        {
            get { return _battery; }
            set
            {
                ThrowIfNotConfigurable();
                _battery = value;
            }
        }

        public ISpiDriver Spi
        {
            get { return _spi; }
            set
            {
                ThrowIfNotConfigurable();
                _spi = value;
            }
        }

        public IGpioDriver Gpio
        {
            get { return _gpio; }
            set
            {
                ThrowIfNotConfigurable();
                _gpio = value;
            }
        }

        public ITouchPanelDriver TouchPanel
        {
            get { return _touchPanel; }
            set
            {
                ThrowIfNotConfigurable();
                _touchPanel = value;
            }
        }

        public IFSDriver FileSystem
        {
            get { return _fileSystem; }
            set
            {
                ThrowIfNotConfigurable();
                _fileSystem = value;
            }
        }

        public IBlockStorageDriver BlockStorage
        {
            get { return _blockStorageDevices; }
            set
            {
                ThrowIfNotConfigurable();
                _blockStorageDevices = value;
            }
        }

        public IWatchdogDriver Watchdog
        {
            get { return _watchdog; }
            set
            {
                ThrowIfNotConfigurable();
                _watchdog = value;
            }
        }

        public IEventsDriver Events
        {
            get { return _events; }
            set
            {
                ThrowIfNotConfigurable();
                _events = value;
            }
        }

        public IMemoryDriver Memory
        {
            get { return _memory; }
            set
            {
                ThrowIfNotConfigurable();
                _memory = value;
            }
        }

        public IUsbDriver Usb
        {
            get { return _usb; }
            set
            {
                ThrowIfNotConfigurable();
                _usb = value;
            }
        }

        public ISocketsDriver Sockets
        {
            get { return _sockets; }
            set
            {
                ThrowIfNotConfigurable();
                _sockets = value;
            }
        }

        public ISslDriver Ssl
        {
            get { return _ssl; }
            set
            {
                ThrowIfNotConfigurable();
                _ssl = value;
            }
        }

        public II2cDriver I2c
        {
            get { return _i2c; }
            set
            {
                ThrowIfNotConfigurable();
                _i2c = value;
            }
        }

        void IHal.EnableInterrupts()
        {
            this.Emulator.EnableInterrupts();
        }

        void IHal.DisableInterrupts()
        {
            this.Emulator.DisableInterrupts();
        }

        bool IHal.AreInterruptsEnabled
        {
            get
            {
                return this.Emulator.AreInterruptsEnabled;
            }
        }

        public override void SetupComponent()
        {
            ThrowIfNull( this.Battery, "Battery" );
            ThrowIfNull( this.Com, "Com" );
            ThrowIfNull( this.Serial, "Serial" );
            ThrowIfNull( this.Spi, "Spi" );
            ThrowIfNull( this.Time, "Time" );
            ThrowIfNull( this.Lcd, "Lcd" );
            ThrowIfNull( this.Gpio, "Gpio" );
            ThrowIfNull( this.Events, "Events" );
            ThrowIfNull( this.Usb, "Usb" );
            ThrowIfNull( this.Memory, "Memory" );
            ThrowIfNull( this.Sockets, "Sockets" );
            ThrowIfNull( this.Ssl, "Ssl" );
            ThrowIfNull( this.I2c, "I2c" );
            ThrowIfNull( this.FileSystem, "FileSystem" );
            ThrowIfNull( this.BlockStorage, "BlockStorage" );
            ThrowIfNull( this.Watchdog, "Watchdog" );

            this.Emulator.RegisterComponent( (EmulatorComponent)_battery, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_com, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_serial, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_spi, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_time, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_lcd, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_gpio, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_events, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_usb, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_memory, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_sockets, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_ssl, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_i2c, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_touchPanel, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_fileSystem, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_blockStorageDevices, this );
            this.Emulator.RegisterComponent( (EmulatorComponent)_watchdog, this );

            base.SetupComponent();
        }

        private void ThrowIfNull( Object o, String name )
        {
            if (o == null)
            {
                throw new Exception( "Hal is missing " + name + " driver component." );
            }
        }

        public Hal()
        {
            _battery = new BatteryDriver();
            _com = new ComDriver();
            _serial = new SerialDriver();
            _spi = new SpiDriver();
            _time = new TimeDriver();
            _lcd = new LcdDriver();
            _gpio = new GpioDriver();
            _events = new EventsDriver();
            _usb = new UsbDriver();
            _memory = new MemoryDriver();
            _sockets = new SocketsDriver();
            _ssl = new SslDriver((SocketsDriver)_sockets);            
            _i2c = new I2cDriver();
            _touchPanel = new TouchPanelDriver();
            _fileSystem = new FSDriver();
            _blockStorageDevices = new BlockStorageDriver();
            _watchdog = new WatchdogDriver();
        }

        public override bool IsReplaceableBy( EmulatorComponent ec )
        {
            return (ec is Hal);
        }
    }

    internal abstract class HalDriver<DriverInterface> : EmulatorComponent
    {
        protected IHal Hal
        {
            get { return this.Emulator.ManagedHal; }
        }

        public override bool IsReplaceableBy( EmulatorComponent ec )
        {
            return (ec is HalDriver<DriverInterface>);
        }
    }
}
