#include "MonoBasics.h"

#include <cassert>
#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>

MonoBasics::MonoBasics(const char *assemblyDir, const char *configDir, const char *domainName, const char *assemblyName) {
    mono_set_dirs(assemblyDir, configDir);
    m_domain = mono_jit_init(domainName);
    assert(m_domain != nullptr);
    m_assembly = mono_domain_assembly_open(m_domain, assemblyName);
    assert(m_assembly != nullptr);
    m_image = mono_assembly_get_image(m_assembly);
    assert(m_image != nullptr);
}

MonoBasics::~MonoBasics() {
    mono_jit_cleanup(m_domain);
}