#pragma once

#include <mono/metadata/object-forward.h>
#include <mono/utils/mono-forward.h>

#include "../Core/Movable.h"

class MonoGame {
public:
    NO_MOVE_OR_COPY(MonoGame)

    MonoGame(MonoDomain *domain, MonoImage *image, const char *nameSpace, const char *name);

    ~MonoGame();

    void Init() const;

    void Shutdown() const;

    void Frame() const;

    void Resize(int width, int height) const;

private:
    MonoClass  *m_class    = nullptr;
    MonoObject *m_instance = nullptr;
    MonoMethod *m_init     = nullptr;
    MonoMethod *m_shutdown = nullptr;
    MonoMethod *m_frame    = nullptr;
    MonoMethod *m_resize   = nullptr;
};