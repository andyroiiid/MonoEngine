#pragma once

#include <mono/metadata/object-forward.h>

class GameClass {
public:
    GameClass(MonoImage *image, const char *nameSpace, const char *name);

    GameClass(const GameClass &)            = delete;
    GameClass(GameClass &&)                 = delete;
    GameClass &operator=(const GameClass &) = delete;
    GameClass &operator=(GameClass &&)      = delete;

    ~GameClass();

    void Init() const;

    void Update() const;

    void Shutdown() const;

private:
    MonoClass  *m_class    = nullptr;
    MonoMethod *m_init     = nullptr;
    MonoMethod *m_update   = nullptr;
    MonoMethod *m_shutdown = nullptr;
};