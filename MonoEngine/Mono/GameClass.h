#pragma once

#include <mono/metadata/object-forward.h>

#include "../Core/Movable.h"

class GameClass {
public:
    NO_MOVE_OR_COPY(GameClass)

    GameClass(MonoImage *image, const char *nameSpace, const char *name);

    ~GameClass();

    void Init() const;

    void Shutdown() const;

    void Update() const;

private:
    MonoClass  *m_class    = nullptr;
    MonoMethod *m_init     = nullptr;
    MonoMethod *m_shutdown = nullptr;
    MonoMethod *m_update   = nullptr;
};