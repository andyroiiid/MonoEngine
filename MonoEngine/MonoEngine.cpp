#include "MonoEngine.h"

#include <glad/glad.h>

static constexpr auto ASSEMBLY_DIR  = "C:/Program Files/Mono/lib";
static constexpr auto CONFIG_DIR    = "C:/Program Files/Mono/etc";
static constexpr auto DOMAIN_NAME   = "MonoEngine";
static constexpr auto ASSEMBLY_NAME = "Game.dll";

MonoEngine::MonoEngine()
    : m_mono{ASSEMBLY_DIR, CONFIG_DIR, DOMAIN_NAME, ASSEMBLY_NAME}
    , m_game{m_mono.GetDomain(), m_mono.GetImage(), "", "Game"} {
    glEnable(GL_BLEND);
    glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

    m_game.Init();
}

MonoEngine::~MonoEngine() {
    m_game.Shutdown();
}

void MonoEngine::Frame() {
    m_game.Frame();
}

void MonoEngine::Resize(const int width, const int height) {
    glViewport(0, 0, width, height);
    m_game.Resize(width, height);
}