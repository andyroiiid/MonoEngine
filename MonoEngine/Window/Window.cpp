#include "Window.h"

#include <GLFW/glfw3.h>
#include <glad/glad.h>
#include <spdlog/spdlog.h>

static Window *g_window = nullptr;

static void LoadGl() {
    const int ret = gladLoadGLLoader(reinterpret_cast<GLADloadproc>(glfwGetProcAddress));
    assert(ret != 0);

#define LOG_GL_STRING(x) spdlog::info(#x ": {}", reinterpret_cast<const char *>(glGetString(x)))
    LOG_GL_STRING(GL_VERSION);
    LOG_GL_STRING(GL_SHADING_LANGUAGE_VERSION);
    LOG_GL_STRING(GL_VENDOR);
    LOG_GL_STRING(GL_RENDERER);
#undef LOG_GL_STRING
}

Window::Window(const char *title, const int width, const int height) {
    assert(g_window == nullptr);
    g_window = this;

    const int ret = glfwInit();
    assert(ret == GLFW_TRUE);

    glfwWindowHint(GLFW_CLIENT_API, GLFW_OPENGL_API);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 6);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
    glfwWindowHint(GLFW_VISIBLE, GLFW_FALSE);
    m_window = glfwCreateWindow(width, height, title, nullptr, nullptr);
    assert(m_window != nullptr);

    glfwSetFramebufferSizeCallback(m_window, [](GLFWwindow *window, const int width, const int height) {
        const auto app = static_cast<App *>(glfwGetWindowUserPointer(window));
        if (app == nullptr) return;
        app->Resize(width, height);
    });

    glfwMakeContextCurrent(m_window);

    LoadGl();
}

Window::~Window() {
    glfwDestroyWindow(m_window);

    glfwTerminate();

    g_window = nullptr;
}

void Window::MainLoop(App *app) {
    glfwShowWindow(m_window);

    glfwSetWindowUserPointer(m_window, app);

    app->Window = this;
    {
        int width, height;
        glfwGetFramebufferSize(m_window, &width, &height);
        app->Resize(width, height);
    }
    while (!glfwWindowShouldClose(m_window)) {
        glfwPollEvents();
        app->Frame();
        glfwSwapBuffers(m_window);
    }
    app->Window = nullptr;

    glfwSetWindowUserPointer(m_window, nullptr);
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Window::SetTitle(const char *title) {
    glfwSetWindowTitle(m_window, title);
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Window::SetSize(const int width, const int height) {
    glfwSetWindowSize(m_window, width, height);
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Window::SetCursor(const bool enabled) {
    glfwSetInputMode(m_window, GLFW_CURSOR, enabled ? GLFW_CURSOR_NORMAL : GLFW_CURSOR_HIDDEN);
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Window::Close() {
    glfwSetWindowShouldClose(m_window, GLFW_TRUE);
}

glm::vec2 Window::GetMousePos() const {
    double x, y;
    glfwGetCursorPos(m_window, &x, &y);
    return {x, y};
}

bool Window::GetKey(const int key) const {
    return glfwGetKey(m_window, key);
}

// Bindings

extern "C" {
__declspec(dllexport) void Window_SetTitle(const char *title) {
    g_window->SetTitle(title);
}

__declspec(dllexport) void Window_SetSize(const int width, const int height) {
    g_window->SetSize(width, height);
}

__declspec(dllexport) void Window_SetCursor(const bool enabled) {
    g_window->SetCursor(enabled);
}

__declspec(dllexport) void Window_Close() {
    g_window->Close();
}

__declspec(dllexport) float Window_GetTime() {
    return static_cast<float>(glfwGetTime());
}

__declspec(dllexport) void Window_GetMousePos(glm::vec2 &position) {
    position = g_window->GetMousePos();
}

__declspec(dllexport) bool Window_GetKey(const int key) {
    return g_window->GetKey(key);
}
}