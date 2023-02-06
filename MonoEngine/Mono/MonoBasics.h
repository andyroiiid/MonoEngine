#pragma once

#include <mono/metadata/image.h>
#include <mono/utils/mono-forward.h>

class MonoBasics {
public:
    MonoBasics(const char *assemblyDir, const char *configDir, const char *domainName, const char *assemblyName);

    MonoBasics(const MonoBasics &)            = delete;
    MonoBasics(MonoBasics &&)                 = delete;
    MonoBasics &operator=(const MonoBasics &) = delete;
    MonoBasics &operator=(MonoBasics &&)      = delete;

    ~MonoBasics();

    [[nodiscard]] MonoImage *GetImage() const { return m_image; }

private:
    MonoDomain   *m_domain   = nullptr;
    MonoAssembly *m_assembly = nullptr;
    MonoImage    *m_image    = nullptr;
};