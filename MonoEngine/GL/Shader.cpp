#include "Shader.h"

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

Shader::Shader(const std::string &vertexSource, const std::string &fragmentSource) {
    const GLuint vertexShader   = CreateShader(GL_VERTEX_SHADER, vertexSource.c_str());
    const GLuint fragmentShader = CreateShader(GL_FRAGMENT_SHADER, fragmentSource.c_str());

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

GLint Shader::GetUniformLocation(const std::string &name) const {
    return glGetUniformLocation(m_program, name.c_str());
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Shader::SetUniform(const GLint location, const float value) {
    glProgramUniform1f(m_program, location, value);
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Shader::SetUniform(const GLint location, const glm::vec2 &value) {
    glProgramUniform2fv(m_program, location, 1, glm::value_ptr(value));
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Shader::SetUniform(const GLint location, const glm::vec3 &value) {
    glProgramUniform3fv(m_program, location, 1, glm::value_ptr(value));
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Shader::SetUniform(const GLint location, const glm::vec4 &value) {
    glProgramUniform4fv(m_program, location, 1, glm::value_ptr(value));
}

// ReSharper disable once CppMemberFunctionMayBeConst
void Shader::SetUniform(const GLint location, const glm::mat4 &value) {
    glProgramUniformMatrix4fv(m_program, location, 1, GL_FALSE, glm::value_ptr(value));
}