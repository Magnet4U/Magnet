package entites;

import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

@Entity
public class Message1 {
@Id
@GeneratedValue (strategy = GenerationType.IDENTITY)
int id_message;
@Temporal(TemporalType.TIMESTAMP)
Date date_message;
String contenu;
int user_dest_id;
@ManyToOne
@JoinColumn(name="user_sender_id")
User user_sender;
public int getId_message() {
	return id_message;
}
public void setId_message(int id_message) {
	this.id_message = id_message;
}
public Date getDate_message() {
	return date_message;
}
public void setDate_message(Date date_message) {
	this.date_message = date_message;
}
public String getContenu() {
	return contenu;
}
public void setContenu(String contenu) {
	this.contenu = contenu;
}
public int getUser_dest_id() {
	return user_dest_id;
}
public void setUser_dest_id(int user_dest_id) {
	this.user_dest_id = user_dest_id;
}
public User getUser_sender() {
	return user_sender;
}
public void setUser_sender(User user_sender) {
	this.user_sender = user_sender;
}





}
