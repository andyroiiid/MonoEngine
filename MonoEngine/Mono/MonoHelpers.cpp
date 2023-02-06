#include "MonoHelpers.h"

#include <mono/metadata/debug-helpers.h>

MonoMethod *SearchMethodInClass(MonoClass *klass, const char *name) {
    if (klass == nullptr) {
        return nullptr;
    }

    MonoMethodDesc *desc = mono_method_desc_new(name, false);
    if (desc == nullptr) {
        return nullptr;
    }

    MonoMethod *method = mono_method_desc_search_in_class(desc, klass);

    mono_method_desc_free(desc);

    return method;
}
