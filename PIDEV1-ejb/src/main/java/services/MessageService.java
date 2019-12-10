package services;

import java.util.ArrayList;
import java.util.Calendar;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;


import entites.Message1;

@Stateless
@LocalBean
public class MessageService {
	@PersistenceContext(unitName = "primary")
	EntityManager em;
	public void envoyerMessage(Message1 e) {
		e.setDate_message(Calendar.getInstance().getTime());
		
	
		em.persist(e);
		
	}
	public ArrayList<Message1> getall(int id )
	{ArrayList<Message1> p ;
	TypedQuery<Message1> query = em
	.createQuery("select c from Message1 AS c where c.user_sender.userId=:id OR c.user_dest_id=:id", Message1.class);
	query.setParameter("id",id);
	p = (ArrayList<Message1>) query.getResultList();
	return p;}
	
	

}
