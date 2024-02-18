#include "PostIntern.hpp"






Bool PostIntern::Init()
{
    return true;
}





void PostIntern::customEvent(QEvent *event)
{
    Int post;

    post = this->Post;



    Post_ExecuteHandle(post);
}