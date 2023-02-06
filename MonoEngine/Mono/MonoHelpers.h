#pragma once

#include <mono/metadata/object-forward.h>

MonoMethod *SearchMethodInClass(MonoClass *klass, const char *name);