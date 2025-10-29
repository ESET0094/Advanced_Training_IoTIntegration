"""Simple command-line REPL for the project.

Features:
- Interactive prompt with history (up/down arrows) when available.
- Built-in commands: help, exit, echo, start-gui, run <python-file>
- Single-command mode via --run argument handled by runner.
"""
import shlex
import subprocess
import sys
import threading
from typing import Callable, Dict

try:
    import readline  # optional; improves interactive experience on Unix and some Windows setups
except Exception:
    readline = None


class CLI:
    def __init__(self, prompt: str = "klyv> "):
        self.prompt = prompt
        self.commands: Dict[str, Callable[[str], None]] = {}
        self._register_builtin_commands()

    def _register_builtin_commands(self):
        self.commands["help"] = self._help
        self.commands["exit"] = self._exit
        self.commands["quit"] = self._exit
        self.commands["echo"] = self._echo
        self.commands["start-gui"] = self._start_gui
        self.commands["run"] = self._run_file

    def _help(self, args: str):
        print("Available commands:")
        print("  help                   Show this message")
        print("  exit, quit             Exit the REPL")
        print("  echo <text>            Print text")
        print("  start-gui              Start the Tkinter GUI (runs in a thread)")
        print("  run <python-file>      Run a python file as a subprocess")

    def _exit(self, args: str):
        print("Bye")
        raise SystemExit(0)

    def _echo(self, args: str):
        print(args)

    def _start_gui(self, args: str):
        """Start the GUI using the inc.gui.create_gui function in a separate thread.

        To avoid blocking the REPL, we spawn a background thread that imports and
        runs the GUI. Note: Tkinter must run on the main thread on some platforms
        (notably macOS). On Windows it's usually fine. If you encounter issues,
        use the `run` command to launch the GUI in a separate process instead.
        """
        def target():
            try:
                from inc.gui import create_gui

                create_gui()
            except Exception as e:
                print("Failed to start GUI in-thread:", e)

        t = threading.Thread(target=target, daemon=True)
        t.start()
        print("GUI started in background thread (may require main-thread on some OSes).")

    def _run_file(self, args: str):
        if not args:
            print("Usage: run <python-file>")
            return
        parts = shlex.split(args)
        cmd = [sys.executable] + parts
        try:
            subprocess.run(cmd, check=False)
        except Exception as e:
            print("Error running file:", e)

    def run_command(self, line: str):
        line = line.strip()
        if not line:
            return
        parts = shlex.split(line)
        cmd = parts[0]
        args = " ".join(parts[1:])
        handler = self.commands.get(cmd)
        if handler:
            try:
                handler(args)
            except SystemExit:
                raise
            except Exception as e:
                print("Error executing command:", e)
        else:
            print(f"Unknown command: {cmd}. Type 'help' for a list of commands.")

    def repl(self):
        try:
            while True:
                try:
                    line = input(self.prompt)
                except EOFError:
                    print()
                    break
                self.run_command(line)
        except SystemExit:
            return


def main(single_command: str = None):
    cli = CLI()
    if single_command:
        cli.run_command(single_command)
        return
    if readline:
        try:
            readline.parse_and_bind("tab: complete")
        except Exception:
            pass
    cli.repl()


if __name__ == "__main__":
    # Allow running a single command via command line args
    if len(sys.argv) > 1:
        main(" ".join(sys.argv[1:]))
    else:
        main()
