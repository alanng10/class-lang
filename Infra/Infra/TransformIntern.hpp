#pragma once


#include <QtGlobal>



class TransformIntern
{
public:

    qreal* Value() { return &(m_matrix[0][0]); }



private:

    qreal m_matrix[3][3];

    mutable uint m_type : 5;
    mutable uint m_dirty : 5;
};
