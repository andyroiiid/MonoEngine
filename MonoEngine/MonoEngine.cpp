#include "MonoEngine.h"

static constexpr auto ASSEMBLY_DIR  = "C:/Program Files/Mono/lib";
static constexpr auto CONFIG_DIR    = "C:/Program Files/Mono/etc";
static constexpr auto DOMAIN_NAME   = "MonoEngine";
static constexpr auto ASSEMBLY_NAME = "Game.dll";

MonoEngine::MonoEngine()
    : m_mono{ASSEMBLY_DIR, CONFIG_DIR, DOMAIN_NAME, ASSEMBLY_NAME}
    , m_gameClass{m_mono.GetImage(), "", "Game"} {
    static const Vertex2D VERTICES[]{
        {{-0.5f, -0.5f}, {0.0f, 0.0f}, {1.0f, 0.0f, 0.0f, 1.0f}},
        {{0.5f, -0.5f},  {1.0f, 0.0f}, {0.0f, 1.0f, 0.0f, 1.0f}},
        {{-0.5f, 0.5f},  {0.0f, 1.0f}, {0.0f, 0.0f, 1.0f, 1.0f}},
        {{0.5f, 0.5f},   {1.0f, 1.0f}, {1.0f, 1.0f, 1.0f, 1.0f}},
    };
    m_quadMesh = Mesh2D(VERTICES, GL_TRIANGLE_STRIP);

    m_gameClass.Init();
}

MonoEngine::~MonoEngine() {
    m_gameClass.Shutdown();
}

void MonoEngine::Frame() {
    m_gameClass.Frame();

    m_shader.Use();
    m_quadMesh.BindAndDraw();
    glBindVertexArray(0);
    glUseProgram(0);
}

void MonoEngine::Resize(const int width, const int height) {
    m_gameClass.Resize(width, height);

    glViewport(0, 0, width, height);
}