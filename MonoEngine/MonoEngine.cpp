#include "MonoEngine.h"

static constexpr auto ASSEMBLY_DIR  = "C:/Program Files/Mono/lib";
static constexpr auto CONFIG_DIR    = "C:/Program Files/Mono/etc";
static constexpr auto DOMAIN_NAME   = "MonoEngine";
static constexpr auto ASSEMBLY_NAME = "Game.dll";

MonoEngine::MonoEngine()
    : m_mono{ASSEMBLY_DIR, CONFIG_DIR, DOMAIN_NAME, ASSEMBLY_NAME}
    , m_gameClass{m_mono.GetImage(), "", "Game"} {
    m_gameClass.Init();
}

MonoEngine::~MonoEngine() {
    m_gameClass.Shutdown();
}

void MonoEngine::Frame() {
    m_gameClass.Frame();
}

void MonoEngine::Resize(const int width, const int height) {
    m_gameClass.Resize(width, height);

    glViewport(0, 0, width, height);
}