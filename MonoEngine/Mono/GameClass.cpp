#include "GameClass.h"

#include <cassert>
#include <mono/metadata/class.h>
#include <mono/metadata/object.h>

#include "MonoHelpers.h"

GameClass::GameClass(MonoImage *image, const char *nameSpace, const char *name) {
    m_class = mono_class_from_name(image, nameSpace, name);
    assert(m_class != nullptr);
    m_init = SearchMethodInClass(m_class, ":Init()");
    assert(m_init != nullptr);
    m_shutdown = SearchMethodInClass(m_class, ":Shutdown()");
    assert(m_shutdown != nullptr);
    m_update = SearchMethodInClass(m_class, ":Update()");
    assert(m_update != nullptr);
}

GameClass::~GameClass() {
    mono_free_method(m_init);
    mono_free_method(m_shutdown);
    mono_free_method(m_update);
}

void GameClass::Init() const {
    mono_runtime_invoke(m_init, nullptr, nullptr, nullptr);
}

void GameClass::Shutdown() const {
    mono_runtime_invoke(m_shutdown, nullptr, nullptr, nullptr);
}

void GameClass::Update() const {
    mono_runtime_invoke(m_update, nullptr, nullptr, nullptr);
}