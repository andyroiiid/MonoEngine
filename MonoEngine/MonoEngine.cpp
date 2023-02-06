#include "Mono/GameClass.h"
#include "Mono/MonoBasics.h"
#include "Window/Window.h"

class Game final : public Window::App {
public:
    void Init() override { m_gameClass.Init(); }

    void Shutdown() override { m_gameClass.Shutdown(); }

    void Update() override { m_gameClass.Update(); }

private:
    static constexpr auto ASSEMBLY_DIR  = "C:/Program Files/Mono/lib";
    static constexpr auto CONFIG_DIR    = "C:/Program Files/Mono/etc";
    static constexpr auto DOMAIN_NAME   = "MonoEngine";
    static constexpr auto ASSEMBLY_NAME = "Game.dll";

    MonoBasics m_mono{ASSEMBLY_DIR, CONFIG_DIR, DOMAIN_NAME, ASSEMBLY_NAME};
    GameClass  m_gameClass{m_mono.GetImage(), "", "Game"};
};

int main() {
    Window window("MonoEngine", 800, 600);
    Game   game;
    window.MainLoop(game);
    return 0;
}