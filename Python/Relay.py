class RelayComponent(UARTInterface):
    def __init__(self):
        self.relay_status = "OFF"
        self.con=None
    def connect(self):
        print("Device Connected")

    def send_command(self,command):
        if command == 'TURN ON':
            cmd_status = self.Write(b'Turn_ON\n')
            return cmd_status
        elif command == 'TURN OFF':
            cmd_status = self.Write(b'Turn_OFF\n')
    
        print("Command Processed")
    def close(self):
        self.con.close()
        print("Closing")
    def Write(self,cmd):
        return b'OK\r\n'
    