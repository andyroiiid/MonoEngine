#pragma once

#include <mono/metadata/image.h>
#include <mono/utils/mono-forward.h>

#include "../Core/Movable.h"

class MonoBasics {
public:
    NO_MOVE_OR_COPY(MonoBasics)

    MonoBasics(const char *assemblyDir, const char *configDir, const char *domainName, const char *assemblyName);

    ~MonoBasics();

    [[nodiscard]] MonoImage *GetImage() const { return m_image; }

private:
    MonoDomain   *m_domain   = nullptr;
    MonoAssembly *m_assembly = nullptr;
    MonoImage    *m_image    = nullptr;
};