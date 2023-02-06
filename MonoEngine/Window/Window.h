#pragma once

// ReSharper disable once CppInconsistentNaming
struct GLFWwindow;

class Window {
public:
    Window(const char *title, int width, int height);

    Window(const Window &)            = delete;
    Window(Window &&)                 = delete;
    Window &operator=(const Window &) = delete;
    Window &operator=(Window &&)      = delete;

    ~Window();

    struct App {
        App()                       = default;
        App(const App &)            = delete;
        App(App &&)                 = delete;
        App &operator=(const App &) = delete;
        App &operator=(App &&)      = delete;
        virtual ~App()              = default;

        virtual void Frame()                       = 0;
        virtual void Resize(int width, int height) = 0;

        Window *Window = nullptr;
    };

    void MainLoop(App *app);

private:
    GLFWwindow *m_window = nullptr;
};