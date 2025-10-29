import tkinter as tk
from pyfiglet import Figlet

def create_gui():
    """Create and run a terminal-like Tkinter GUI frontend.

    This creates a read-only output area and an input entry with history
    navigation. Backend integration can be plugged into `handle_command()`.
    """
    root = tk.Tk()
    root.title("Klyv Terminal")
    root.geometry("700x450")
    root.configure(bg="black")
    f = Figlet(font='slant')
    ascii_text = f.renderText("Klyv")
    welcome_label = tk.Label(root, 
                        text=ascii_text, 
                        font=("Courier", 10, "bold"),
                        
                        justify = tk.CENTER)
    welcome_label.pack(pady=20)
    # Main container
    frame = tk.Frame(root, bg="black")
    frame.pack(fill="both", expand=True, padx=10, pady=10)

    # Text output area with scrollbar
    text_frame = tk.Frame(frame, bg="black")
    text_frame.pack(fill="both", expand=True)

    output = tk.Text(
        text_frame,
        wrap="word",
        bg="#0b0b0b",
        fg="#f1f1f1",
        insertbackground="#f1f1f1",
        state="disabled",
        relief="flat",
    )
    output.pack(side="left", fill="both", expand=True)

    scrollbar = tk.Scrollbar(text_frame, command=output.yview)
    scrollbar.pack(side="right", fill="y")
    output.config(yscrollcommand=scrollbar.set)

    # Input area
    input_frame = tk.Frame(frame, bg="#111")
    input_frame.pack(fill="x", side="left", pady=(8, 0))

    entry = tk.Entry(
        input_frame,
        bg="#111", # very dark gray
        fg="#fff", # white
        insertbackground="#fff", # white cursor
        relief="solid", # with border
    )
    entry.pack(side="left", fill="x", expand=True, padx=(6, 6), pady=6)

    send_btn = tk.Button(input_frame, text="Send", width=10)
    send_btn.pack(side="right", padx=(0, 6), pady=6)

    # Command history (simple list + mutable index container)
    history = []
    hist_pos = [None]  # None means not navigating history

    def write_output(text: str):
        """Append text to the output area and scroll to end."""
        output.config(state="normal")
        output.insert("end", text + "\n")
        output.see("end")
        output.config(state="disabled")

    def handle_command(cmd: str):
        """Placeholder command handler. Replace or extend this to call backend.

        For now the frontend will echo the command and print a fake response.
        """
        cmd = cmd.strip()
        if not cmd:
            return
        # Add to history
        history.append(cmd)
        hist_pos[0] = None

        # Echo the command and show a placeholder response
        write_output(f">> {cmd}")
        # Simulated response (backend integration point)
        write_output(f"{cmd}")

    def submit_command(event=None):
        cmd = entry.get()
        entry.delete(0, "end")
        handle_command(cmd)
        return "break"

    def history_up(event=None):
        if not history:
            return "break"
        if hist_pos[0] is None:
            hist_pos[0] = len(history) - 1
        else:
            hist_pos[0] = max(0, hist_pos[0] - 1)
        entry.delete(0, "end")
        entry.insert(0, history[hist_pos[0]])
        return "break"

    def history_down(event=None):
        if not history or hist_pos[0] is None:
            return "break"
        hist_pos[0] = min(len(history) - 1, hist_pos[0] + 1)
        # If moved past last, clear
        if hist_pos[0] >= len(history):
            entry.delete(0, "end")
            hist_pos[0] = None
        else:
            entry.delete(0, "end")
            entry.insert(0, history[hist_pos[0]])
        return "break"

    # Bindings
    entry.bind("<Return>", submit_command)
    entry.bind("<Up>", history_up)
    entry.bind("<Down>", history_down)
    send_btn.config(command=submit_command)

    # Put a welcome message
    write_output("Klyv terminal frontend ready. Type commands and press Enter.")

    root.mainloop()


if __name__ == "__main__":
    create_gui()