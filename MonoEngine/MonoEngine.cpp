#include <GLFW/glfw3.h>
#include <cassert>
#include <glad/glad.h>
#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>

#include "Mono/GameClass.h"

void MainLoop(MonoImage *image, GLFWwindow *window) {
    const GameClass gameClass(image, "", "Game");
    gameClass.Init();
    while (!glfwWindowShouldClose(window)) {
        glfwPollEvents();
        gameClass.Update();
        glfwSwapBuffers(window);
    }
    gameClass.Shutdown();
}

int main() {
    glfwInit();

    glfwWindowHint(GLFW_CLIENT_API, GLFW_OPENGL_API);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 6);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
    GLFWwindow *window = glfwCreateWindow(800, 600, "MonoEngine", nullptr, nullptr);

    glfwMakeContextCurrent(window);

    gladLoadGLLoader(reinterpret_cast<GLADloadproc>(glfwGetProcAddress));

    printf("GL_VERSION = %s\n", reinterpret_cast<const char *>(glGetString(GL_VERSION)));
    printf("GL_SHADING_LANGUAGE_VERSION = %s\n", reinterpret_cast<const char *>(glGetString(GL_SHADING_LANGUAGE_VERSION)));
    printf("GL_VENDOR = %s\n", reinterpret_cast<const char *>(glGetString(GL_VENDOR)));
    printf("GL_RENDERER = %s\n", reinterpret_cast<const char *>(glGetString(GL_RENDERER)));

    mono_set_dirs("C:/Program Files/Mono/lib", "C:/Program Files/Mono/etc");

    MonoDomain *domain = mono_jit_init("MonoExperiments");
    assert(domain != nullptr);

    MonoAssembly *assembly = mono_domain_assembly_open(domain, "Game.dll");
    assert(assembly != nullptr);

    MonoImage *image = mono_assembly_get_image(assembly);
    assert(image != nullptr);

    MainLoop(image, window);

    mono_jit_cleanup(domain);

    glfwDestroyWindow(window);

    return 0;
}