﻿#include "Shader.h"

#include <glm/gtc/type_ptr.hpp>
#include <spdlog/spdlog.h>

static GLuint CreateShader(const GLenum type, const char *source) {
    const GLuint shader = glCreateShader(type);

    glShaderSource(shader, 1, &source, nullptr);
    glCompileShader(shader);

    GLint compileStatus = 0;
    glGetShaderiv(shader, GL_COMPILE_STATUS, &compileStatus);
    if (compileStatus != GL_TRUE) {
        GLint infoLogLength = 0;
        glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infoLogLength);
        const auto infoLog = new GLchar[infoLogLength];
        glGetShaderInfoLog(shader, infoLogLength, &infoLogLength, infoLog);
        spdlog::error("Failed to load shader: {}", infoLog);
        delete[] infoLog;
        glDeleteShader(shader);
        return 0;
    }

    return shader;
}

static GLuint CreateProgram(const std::initializer_list<GLuint> &shaders) {
    const GLuint program = glCreateProgram();

    for (const GLuint shader: shaders)
        glAttachShader(program, shader);
    glLinkProgram(program);

    GLint linkStatus = 0;
    glGetProgramiv(program, GL_LINK_STATUS, &linkStatus);
    if (linkStatus != GL_TRUE) {
        GLint infoLogLength = 0;
        glGetProgramiv(program, GL_INFO_LOG_LENGTH, &infoLogLength);
        const auto infoLog = new GLchar[infoLogLength];
        glGetProgramInfoLog(program, infoLogLength, &infoLogLength, infoLog);
        spdlog::error("Failed to link program: {}", infoLog);
        delete[] infoLog;
        glDeleteProgram(program);
        return 0;
    }

    for (const GLuint shader: shaders)
        glDetachShader(program, shader);
    return program;
}

Shader::Shader(const char *vertexSource, const char *fragmentSource) {
    const GLuint vertexShader   = CreateShader(GL_VERTEX_SHADER, vertexSource);
    const GLuint fragmentShader = CreateShader(GL_FRAGMENT_SHADER, fragmentSource);

    m_program = CreateProgram({vertexShader, fragmentShader});

    glDeleteShader(vertexShader);
    glDeleteShader(fragmentShader);
}

Shader::~Shader() {
    if (m_program) glDeleteProgram(m_program);
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Shader::Use() {
    glUseProgram(m_program);
}

GLint Shader::GetUniformLocation(const char *name) const {
    return glGetUniformLocation(m_program, name);
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Shader::SetUniform(const GLint location, const float x) {
    glProgramUniform1f(m_program, location, x);
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Shader::SetUniform(const GLint location, const float x, const float y) {
    glProgramUniform2f(m_program, location, x, y);
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Shader::SetUniform(const GLint location, const float x, const float y, const float z) {
    glProgramUniform3f(m_program, location, x, y, z);
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Shader::SetUniform(const GLint location, const float x, const float y, const float z, const float w) {
    glProgramUniform4f(m_program, location, x, y, z, w);
}