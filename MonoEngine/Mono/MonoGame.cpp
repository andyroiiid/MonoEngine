#include "MonoGame.h"

#include <cassert>
#include <mono/metadata/class.h>
#include <mono/metadata/object.h>

#include "MonoHelpers.h"

MonoGame::MonoGame(MonoDomain *domain, MonoImage *image, const char *nameSpace, const char *name) {
    m_class = mono_class_from_name(image, nameSpace, name);
    assert(m_class != nullptr);
    m_instance = mono_object_new(domain, m_class);
    assert(m_instance != nullptr);
    m_init = SearchMethodInClass(m_class, ":Init()");
    assert(m_init != nullptr);
    m_shutdown = SearchMethodInClass(m_class, ":Shutdown()");
    assert(m_shutdown != nullptr);
    m_frame = SearchMethodInClass(m_class, ":Frame()");
    assert(m_frame != nullptr);
    m_resize = SearchMethodInClass(m_class, ":Resize(int,int)");
    assert(m_resize != nullptr);
}

MonoGame::~MonoGame() {
    mono_free_method(m_init);
    mono_free_method(m_shutdown);
    mono_free_method(m_frame);
    mono_free_method(m_resize);
}

void MonoGame::Init() const {
    mono_runtime_invoke(m_init, m_instance, nullptr, nullptr);
}

void MonoGame::Shutdown() const {
    mono_runtime_invoke(m_shutdown, m_instance, nullptr, nullptr);
}

void MonoGame::Frame() const {
    mono_runtime_invoke(m_frame, m_instance, nullptr, nullptr);
}

void MonoGame::Resize(int width, int height) const {
    void *params[2];
    params[0] = &width;
    params[1] = &height;
    mono_runtime_invoke(m_resize, m_instance, params, nullptr);
}