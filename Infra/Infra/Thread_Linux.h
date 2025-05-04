#pragma once

#include <unistd.h>
#include <pthread.h>
#include <signal.h>
#include <string.h>

#include "Pronate.h"

static void SignalHandle(int signal);
