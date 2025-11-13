from abc import ABC, abstractmethod
def UARTInterface(ABC):
    @abstractmethod
    def connect(self):
        pass
    def send_command(self):
        pass
    def send_data(self):
        pass