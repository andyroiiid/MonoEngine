#include "Texture.h"

#include <spdlog/spdlog.h>
#define STB_IMAGE_IMPLEMENTATION
#include <stb_image.h>

Texture::Texture(const glm::ivec2 &size, const unsigned char *data, const Wrap wrap, const bool filter, const bool mipmaps) {
    m_size = size;

    glCreateTextures(GL_TEXTURE_2D, 1, &m_texture);
    glTextureStorage2D(m_texture, 1, GL_RGBA8, size.x, size.y);
    glTextureSubImage2D(m_texture, 0, 0, 0, size.x, size.y, GL_RGBA, GL_UNSIGNED_BYTE, data);

    if (filter) {
        glTextureParameteri(m_texture, GL_TEXTURE_MIN_FILTER, mipmaps ? GL_LINEAR_MIPMAP_LINEAR : GL_LINEAR);
        glTextureParameteri(m_texture, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
    } else {
        glTextureParameteri(m_texture, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
        glTextureParameteri(m_texture, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
    }

    switch (wrap) {
    case Wrap::Repeat:
        glTextureParameteri(m_texture, GL_TEXTURE_WRAP_S, GL_REPEAT);
        glTextureParameteri(m_texture, GL_TEXTURE_WRAP_T, GL_REPEAT);
        break;
    case Wrap::Clamp:
        glTextureParameteri(m_texture, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
        glTextureParameteri(m_texture, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);
        break;
    case Wrap::MirrorRepeat:
        glTextureParameteri(m_texture, GL_TEXTURE_WRAP_S, GL_MIRRORED_REPEAT);
        glTextureParameteri(m_texture, GL_TEXTURE_WRAP_T, GL_MIRRORED_REPEAT);
        break;
    }

    if (mipmaps) {
        glGenerateTextureMipmap(m_texture);
    }
}

Texture::~Texture() {
    if (m_texture) {
        glDeleteTextures(1, &m_texture);
    }
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Texture::Bind(const GLuint unit) {
    glBindTextureUnit(unit, m_texture);
}

// Bindings

extern "C" {
__declspec(dllexport) void Texture_Destroy(const Texture *texture) {
    delete texture;
}

__declspec(dllexport) Texture *Texture_Create(int width, int height, const unsigned char *data) {
    return new Texture({width, height}, data, Texture::Wrap::Clamp, false, false);
}

__declspec(dllexport) Texture *Texture_LoadFromMemory(const unsigned char *bytes, const int length) {
    stbi_set_flip_vertically_on_load(true);
    int            width  = 0;
    int            height = 0;
    unsigned char *data   = stbi_load_from_memory(bytes, length, &width, &height, nullptr, 4);
    Texture       *result = Texture_Create(width, height, data);
    stbi_image_free(data);
    return result;
}

__declspec(dllexport) void Texture_GetSize(const Texture *texture, glm::vec2 &size) {
    size = texture->GetSize();
}

__declspec(dllexport) void Texture_Bind(Texture *texture, const unsigned int unit) {
    texture->Bind(unit);
}
}