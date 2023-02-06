#include "MonoEngine.h"
#include "Window/Window.h"

int main() {
    Window     window("MonoEngine", 800, 600);
    MonoEngine engine;
    window.MainLoop(&engine);
    return 0;
}