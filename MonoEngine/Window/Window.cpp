#include "Window.h"

#include <GLFW/glfw3.h>
#include <glad/glad.h>
#include <spdlog/spdlog.h>

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
    const int ret = glfwInit();
    assert(ret == GLFW_TRUE);

    glfwWindowHint(GLFW_CLIENT_API, GLFW_OPENGL_API);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 6);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
    m_window = glfwCreateWindow(width, height, title, nullptr, nullptr);
    assert(m_window != nullptr);

    glfwMakeContextCurrent(m_window);

    LoadGl();
}

Window::~Window() {
    glfwDestroyWindow(m_window);

    glfwTerminate();
}

void Window::MainLoop(App &app) {
    app.m_window = this;
    app.Init();
    while (!glfwWindowShouldClose(m_window)) {
        glfwPollEvents();
        app.Update();
        glfwSwapBuffers(m_window);
    }
    app.Shutdown();
    app.m_window = nullptr;
}